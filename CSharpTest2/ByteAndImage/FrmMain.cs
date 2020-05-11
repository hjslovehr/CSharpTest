using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ByteAndImage
{
    public partial class FrmMain : Form
    {
        private byte[] _imageByteArray = null;

        public FrmMain()
        {
            InitializeComponent();
        }

        private async void btnImageToBytesTest_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Multiselect = false;
            //dlg.Filter = "Image files(*.JPG;*.BMP;*.GIF)|*.JPG;*.BMP;*.GIF|All files (*.*)|*.*";
            dlg.Filter = "Image file(*.JPG)|*.JPG|All files(*.*)|*.*";

            var result = dlg.ShowDialog();
            if (DialogResult.OK != result)
            {
                return;
            }

            string fileName = dlg.FileName;
            Console.WriteLine($"你选择了 {fileName} 文件");

            #region Task.Factory.StartNew
            //await Task.Factory.StartNew(obj =>
            //{
            //    var image = Image.FromFile((string)obj);
            //    var ms = new MemoryStream();
            //    image.Save(ms, ImageFormat.Jpeg);

            //    _imageByteArray = ms.ToArray();

            //    var str = Encoding.UTF8.GetString(_imageByteArray);

            //    Console.Write(str);

            //}, fileName);
            #endregion

            await Task.Run(() =>
            {
                var image = Image.FromFile(fileName);
                var ms = new MemoryStream();
                image.Save(ms, ImageFormat.Jpeg);

                _imageByteArray = ms.ToArray();

                var str = Encoding.UTF8.GetString(_imageByteArray);
                
                var pin = "PIN=" + Path.GetFileName(fileName);
                var sn = "SN=" + "1234567";
                var size = "size=" + _imageByteArray.Length;
                var cmd = "CMD=" + "uploadphoto";
                byte zero = (byte)'\0';

                var header = $"{pin}\n{sn}\n{size}\n{cmd}";
                Console.WriteLine(header);

                var byteHeaderArray = Encoding.UTF8.GetBytes(header);
                var totalBufferLength = byteHeaderArray.Length + 1 + _imageByteArray.Length;

                var tempByteArray = new byte[totalBufferLength];
                Buffer.BlockCopy(byteHeaderArray, 0, tempByteArray, 0, byteHeaderArray.Length);
                tempByteArray[byteHeaderArray.Length] = zero;
                Buffer.BlockCopy(_imageByteArray, 0, tempByteArray, byteHeaderArray.Length + 1, _imageByteArray.Length);

                _imageByteArray = tempByteArray;

                GC.Collect();

                //Console.Write(str);
            });
        }

        private async void btnBytesToImageTest_Click(object sender, EventArgs e)
        {
            var ms = new MemoryStream();
            Image img = null;

            await Task.Run(() => {
                var firstZeroPosition = 0;
                foreach (var item in _imageByteArray)
                {
                    if (item.Equals((byte)'\0'))
                    {
                        break;
                    }

                    ++firstZeroPosition;
                }

                var headerByteArray = new byte[firstZeroPosition];
                Buffer.BlockCopy(_imageByteArray, 0, headerByteArray, 0, firstZeroPosition);

                var header = Encoding.UTF8.GetString(headerByteArray);
                Console.WriteLine(header);

                
                ms.Write(_imageByteArray, firstZeroPosition + 1, _imageByteArray.Length - (firstZeroPosition + 1));
                img = Image.FromStream(ms);
            });

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "JPG file(*.jpg)|*.jpg";

            var result = dlg.ShowDialog();
            if (DialogResult.OK != result)
            {
                return;
            }

            var fileName = dlg.FileName;
            img.Save(fileName, ImageFormat.Jpeg);

            Console.WriteLine("Save image : " + fileName);
        }
    }
}
