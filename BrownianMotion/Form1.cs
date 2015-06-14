using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrownianMotion {
	public partial class Form1 : Form {
		Bitmap updatedImage;
		int crop = 1280;
		public Form1() {
			InitializeComponent();
		}

		//Start line generator
		private void button1_Click(object sender, EventArgs e) {
			if (!backgroundWorker1.IsBusy) {
				button1.Text = "Cancel";
				checkBox2.Enabled = false;
				numericUpDown1.Enabled = false;
				if (pictureBox1.Image == null || !checkBox2.Checked) {
					resetPictureBox();
				}
				backgroundWorker1.RunWorkerAsync();
			} else if (backgroundWorker1.WorkerSupportsCancellation) {
				backgroundWorker1.CancelAsync();
			}

		}

		//reset pictureBox1 to white rectangle
		private void button2_Click(object sender, EventArgs e) {
			resetPictureBox();
		}

		//Fills in pictureBox1 with white rectangle
		private void resetPictureBox() {
			Bitmap Bmp = new Bitmap(2561, 2561);
			Graphics g = Graphics.FromImage(Bmp);
			g.FillRectangle(new SolidBrush(Color.White), 0, 0, 2561, 2561);
			crop = 1280;
			setImage(Bmp);
		}
		//render image in pictureBox1
		private void setImage(Bitmap img) {
			double? widthScale = pictureBox1.Width / (double)img.Width;
			double? heightScale = pictureBox1.Height / (double)img.Height;
			double scale = Math.Min((double)(widthScale ?? heightScale),
									 (double)(heightScale ?? widthScale));
			var bmp2 = new Bitmap((int)Math.Floor(img.Width * scale), (int)Math.Ceiling(img.Height * scale));
			using (Graphics g = Graphics.FromImage(bmp2)) {
				g.InterpolationMode = InterpolationMode.NearestNeighbor;
				g.DrawImage(cropAtRect(img, new Rectangle(crop, crop, 2561 - crop * 2, 2561 - crop * 2)), new Rectangle(0, 0, bmp2.Size.Width, bmp2.Size.Height));
				pictureBox1.Image = bmp2;
				updatedImage = img;
			}
		}
		//crops the image to where the generated stuff is
		private Bitmap cropAtRect(Bitmap b, Rectangle r) {
			Bitmap nb = new Bitmap(r.Width, r.Height);
			Graphics g = Graphics.FromImage(nb);
			g.DrawImage(b, -r.X, -r.Y);
			return nb;
		}
		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) {
			BackgroundWorker worker = sender as BackgroundWorker;
			int center = 1280, x = 0, y = 0;
			Bitmap image = updatedImage;
			Random random = new Random(Guid.NewGuid().GetHashCode());
			Color color = Color.FromArgb((byte)random.Next(0, 256), (byte)random.Next(0, 256), (byte)random.Next(0, 256));
			try {
				using (Graphics g = Graphics.FromImage(image)) {
					for (int i = 0; i < numericUpDown1.Value; i++) {
						if (worker.CancellationPending)
							return;
						x = putInside(x + random.Next(-1, 2));
						y = putInside(y + random.Next(-1, 2));
						int min = Math.Min(Math.Min(center - x, center + x), Math.Min(center + y, center - y));
						crop = ((min < crop) ? min : crop);
						//draw line and duplicates
						image.SetPixel(center + x, center + y, color);
						image.SetPixel(center + x, center - y, color);
						image.SetPixel(center - x, center + y, color);
						image.SetPixel(center - x, center - y, color);

						image.SetPixel(center + y, center + x, color);
						image.SetPixel(center - y, center + x, color);
						image.SetPixel(center + y, center - x, color);
						image.SetPixel(center - y, center - x, color);
						color = Color.FromArgb(
							secureColor(color.R, random.Next(-10, 11)),
							secureColor(color.G, random.Next(-10, 11)),
							secureColor(color.B, random.Next(-10, 11))
						);
						if (checkBox1.Checked) {
							setImage(image);
						}
						worker.ReportProgress((100 * i) / (int)numericUpDown1.Value);
					}
					if (!checkBox1.Checked) {
						setImage(image);
					}
				}
			} catch (Exception ex) {
				MessageBox.Show(ex.ToString(),
				"Error generating image.",
				MessageBoxButtons.OK,
				MessageBoxIcon.Error);
			}
		}
		//makes sure coords are inside the image
		private int putInside(int coord) {
			if (1280 + coord >= 2561 || 1280 - coord >= 2561) {
				return 2561;
			} else if (1280 + coord < 0 || 1280 - coord < 0) {
				return 0;
			}
			return coord;
		}
		//makes sure color is valid byte
		private byte secureColor(byte col, int add) {
			if ((col + add) > 255) {
				return 255;
			} else if ((col + add) < 0) {
				return 0;
			}
			return (byte)(col + add);
		}

		private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) {
			progressBar1.Value = e.ProgressPercentage;
			label2.Text = e.ProgressPercentage + "%";
		}
		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
			if (e.Cancelled == true) {
				label2.Text = "Canceled!";
			} else if (e.Error != null) {
				label2.Text = "Error: " + e.Error.Message;
			} else {
				label2.Text = "Done!";
			}
			button1.Text = "Generate";
			checkBox2.Enabled = true;
			numericUpDown1.Enabled = true;
			progressBar1.Value = 0;
		}
		//resize image when form size changes
		private void pictureBox1_Update(object sender, EventArgs e) {
			if (!backgroundWorker1.IsBusy) {
				setImage(updatedImage);
			}
		}
	}
}
