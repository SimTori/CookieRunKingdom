using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieRunKingdom
{
    public class ImaData
    {
        public string fileName;             // 파일명
        public string path;                 // 파일 전체 경로
        public string folderPath;           // 폴더명까지의 경로
        public Pos pos;                     // 이미지의 검색 범위
        public float allow;                 // 이미지의 오차율
        private Image<Bgr, byte> _image;    // cv용 이미지 저장 변수

        public ImaData( string fileName, string folderPath, int pos1, int pos2, int pos3, int pos4, float allow)
        {
            this.fileName = fileName;
            this.folderPath = folderPath;
            this.path = folderPath + "\\" + fileName + ".bmp";
            this.pos = new Pos(pos1, pos2, pos3, pos4);
            this.allow = allow;
        }

        public void ResetPos(Rectangle rect)
        {
            ResetPos(rect.X, rect.Y, rect.X + rect.Width, rect.Y + rect.Height);
        }

        public void ResetPos(int pos1, int pos2, int pos3, int pos4)
        {
            this.pos = new Pos(pos1, pos2, pos3, pos4);
        }

        public Image<Bgr, byte> Image
        {
            get
            {
                if (_image == null)
                {
                    if (string.IsNullOrEmpty(fileName) == false)
                    {
                        this._image = new Image<Bgr, byte>(this.path);
                    }
                }
                return _image;
            }
            set => _image = value;
        }

        public void ResetImage(string fileName)
        {
            if (this._image != null)
            {
                this._image.Dispose();
                this._image = null;
            }
            this.fileName = fileName;
            this.path = folderPath + "\\" + fileName + ".bmp";
            this._image = new Image<Bgr, byte>(this.path);
        }
    }
}
