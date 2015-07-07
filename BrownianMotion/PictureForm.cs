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
	public partial class PictureForm : Form {
		public ControlForm cForm = null;
		public PictureForm() {
			InitializeComponent();
		}
		public PictureForm(Form callingForm) {
			InitializeComponent();
			cForm = callingForm as ControlForm;
		}

		//resize image when form size changes
		public void pictureBox1_Update(object sender, EventArgs e) {
			if (!cForm.backgroundWorker1.IsBusy) {
				cForm.setImage(cForm.updatedImage);
			}
		}
	}
}
