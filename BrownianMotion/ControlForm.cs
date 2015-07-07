using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrownianMotion {
	public partial class ControlForm : Form {
		public static PictureForm pForm = new PictureForm();
		public Bitmap updatedImage = new Bitmap(1, 1);
		public static int maxSize = ((getMaxSize() % 2 == 1) ? getMaxSize() : (getMaxSize() + 1));
		public static int crop = ((maxSize - 1) / 2);

		public ControlForm() {
			InitializeComponent();
			pForm.Show();
			updateColor();
			pForm.pictureBox1.SizeChanged += new System.EventHandler(pictureBox1_Update);
			saveFile.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff|All Files|*.*";
		}

		//Start line generator
		public void button1_Click(object sender, EventArgs e) {
			if (!backgroundWorker1.IsBusy) {
				button1.Text = "Cancel";
				//First run or Add layer?
				if (pForm.pictureBox1.Image == null || !checkBox2.Checked) {
					resetPictureBox();
				}//
				backgroundWorker1.RunWorkerAsync();
				changeBools(true);
			} else if (backgroundWorker1.WorkerSupportsCancellation) {
				backgroundWorker1.CancelAsync();
			}
		}//

		//resize image when form size changes
		public void pictureBox1_Update(object sender, EventArgs e) {
			resizePictureBox();
		}//

		//Reset pictureBox1 to white rectangle
		public void button2_Click(object sender, EventArgs e) {
			resetPictureBox();
		}//

		//Fill in pictureBox1 with white rectangle
		public void resetPictureBox() {
			Bitmap Bmp = new Bitmap(maxSize, maxSize);
			crop = ((maxSize - 1) / 2);
			setImage(Bmp);
		}//

		//Resize picturebox to fit new window
		public void resizePictureBox() {
			if (!backgroundWorker1.IsBusy) {
				setImage(updatedImage);
			}
		}//

		//Render image in pictureBox1
		public void setImage(Bitmap img) {
			int size = Math.Min(pForm.pictureBox1.Height, pForm.pictureBox1.Width);
			Bitmap newImage = new Bitmap(size, size);//Memory bug/error resides here
			using (Graphics g = Graphics.FromImage(newImage)) {
				g.InterpolationMode = InterpolationMode.NearestNeighbor;
				g.PixelOffsetMode = PixelOffsetMode.Half;
				g.DrawImage(cropAtRect(img), new Rectangle(0, 0, size, size));
			}
			if (pForm.pictureBox1.Image != null) {
				pForm.pictureBox1.Image.Dispose();
			}
			pForm.pictureBox1.Image = newImage;
			updatedImage = img;
		}//

		//Crop the image to generated area
		public Bitmap cropAtRect(Bitmap b) {
			Rectangle r = new Rectangle(crop, crop, maxSize - crop * 2, maxSize - crop * 2);
			Bitmap nb = new Bitmap(r.Width, r.Height);
			using (Graphics g = Graphics.FromImage(nb)) {
				g.DrawImage(b, -r.X, -r.Y);
			}
			return nb;
		}//

		//Main code to generate the image
		public void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
			BackgroundWorker worker = sender as BackgroundWorker;
			int center = ((maxSize - 1) / 2), x = 0, y = 0;
			Bitmap image = updatedImage;
			Random random = new Random(Guid.NewGuid().GetHashCode());
			Color color;
			//Custom color?
			if (checkBox3.Checked) {
				color = Color.FromArgb(byte.Parse(numericUpDownR.Value.ToString()), byte.Parse(numericUpDownG.Value.ToString()), byte.Parse(numericUpDownB.Value.ToString()));
			} else {
				color = Color.FromArgb((byte)random.Next(0, 256), (byte)random.Next(0, 256), (byte)random.Next(0, 256));
			}
			try {
				for (int i = 0; i < numericUpDown1.Value; i++) {
					if (worker.CancellationPending)
						return;
					x = putInside(x + random.Next(-1, 2));
					y = putInside(y + random.Next(-1, 2));
					int min = Math.Min(Math.Min(center - x, center + x), Math.Min(center + y, center - y));
					crop = ((min < crop) ? min : crop);
					//Draw line and duplicates
					image.SetPixel(center + x, center + y, color);
					image.SetPixel(center + x, center - y, color);
					image.SetPixel(center - x, center + y, color);
					image.SetPixel(center - x, center - y, color);

					image.SetPixel(center + y, center + x, color);
					image.SetPixel(center - y, center + x, color);
					image.SetPixel(center + y, center - x, color);
					image.SetPixel(center - y, center - x, color);

					//Change color for next iteration
					int change = (int)numericUpDown2.Value;
					color = Color.FromArgb(
						secureColor(color.R, random.Next(-change, change + 1)),
						secureColor(color.G, random.Next(-change, change + 1)),
						secureColor(color.B, random.Next(-change, change + 1))
					);
					worker.ReportProgress((100 * i) / (int)numericUpDown1.Value);
					//Watch?
					if (checkBox1.Checked) {
						setImage(image);
					}
				}
				if (!checkBox1.Checked) {
					setImage(image);
				}
			} catch (Exception ex) {
				MessageBox.Show(ex.ToString(),
				"Error generating image.",
				MessageBoxButtons.OK,
				MessageBoxIcon.Error);
			}
		}//

		//Make sure coords are inside the image
		public int putInside(int coord) {
			if (((maxSize - 1) / 2) + coord >= maxSize || ((maxSize - 1) / 2) - coord >= maxSize) {
				return maxSize;
			} else if (((maxSize - 1) / 2) + coord < 0 || ((maxSize - 1) / 2) - coord < 0) {
				return 0;
			}
			return coord;
		}//

		//Make sure color is valid byte
		public byte secureColor(byte col, int add) {
			if ((col + add) > 255) {
				return 255;
			} else if ((col + add) < 0) {
				return 0;
			}
			return (byte)(col + add);
		}//

		//Update progress label and bar
		public void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) {
			progressBar1.Value = e.ProgressPercentage;
			label1.Text = e.ProgressPercentage + "%";
		}
		public void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			if (e.Cancelled == true) {
				label1.Text = "Canceled!";
			} else if (e.Error != null) {
				label1.Text = "Error: " + e.Error.Message;
			} else {
				label1.Text = "Done!";
			}
			button1.Text = "Generate";
			progressBar1.Value = 0;
			changeBools(false);
		}//

		//Update color preview
		public void numericUpDownR_ValueChanged(object sender, EventArgs e) {
			updateColor();
		}
		public void numericUpDownG_ValueChanged(object sender, EventArgs e) {
			updateColor();
		}
		public void numericUpDownB_ValueChanged(object sender, EventArgs e) {
			updateColor();
		}
		public void updateColor() {
			Bitmap Bmp = new Bitmap(78, 78);
			using (Graphics g = Graphics.FromImage(Bmp)) {
				g.FillRectangle(new SolidBrush(Color.FromArgb(
					byte.Parse(numericUpDownR.Value.ToString()),
					byte.Parse(numericUpDownG.Value.ToString()),
					byte.Parse(numericUpDownB.Value.ToString()))), 0, 0, 78, 78);
				pictureBox1.Image = Bmp;
			}
		}//

		//Update control states
		public void changeBools(bool starting) {
			button2.Enabled = !starting;
			checkBox2.Enabled = !starting;
			checkBox3.Enabled = !starting;
			numericUpDown1.Enabled = !starting;
			numericUpDown2.Enabled = !starting;
			if (checkBox3.Checked) {
				numericUpDownR.Enabled = !starting;
				numericUpDownG.Enabled = !starting;
				numericUpDownB.Enabled = !starting;
			}
		}
		public void checkBox3_CheckedChanged(object sender, EventArgs e) {
			numericUpDownR.Enabled = checkBox3.Checked;
			numericUpDownG.Enabled = checkBox3.Checked;
			numericUpDownB.Enabled = checkBox3.Checked;
		}//		

		//Get the smallest of the two resolutions
		public static int getMaxSize() {
			return Math.Min(Screen.PrimaryScreen.Bounds.Height, Screen.PrimaryScreen.Bounds.Width);
		}//

		//Save image
		public readonly SaveFileDialog saveFile = new SaveFileDialog();
		public void button2_Click_1(object sender, EventArgs e) {
			if (saveFile.ShowDialog() == DialogResult.OK) {
				try {
					cropAtRect(updatedImage).Save(saveFile.FileName);
				} catch (Exception ex) {
					MessageBox.Show(ex.ToString(),
									"Error saving image",
									MessageBoxButtons.OK,
									MessageBoxIcon.Error);
				}
			}
		}
	}
}
