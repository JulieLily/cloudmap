using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Drawing.Imaging;
using System.Threading.Tasks;

using ThoughtWorks.QRCode.Codec;
using ThoughtWorks.QRCode.Codec.Data;
using ThoughtWorks.QRCode.Codec.Util;

namespace TOPSUN.ERP.Common.Utilities
{
    public static class QRCodeUtil
    {
        public static Image GenerateQRCode(string text, string mode, int scale, int version, string errorCorrect)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();

            String encoding = mode ;
            if (encoding == "Byte") {
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            } else if (encoding == "AlphaNumeric") {
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.ALPHA_NUMERIC;            
            } else if (encoding == "Numeric") {
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.NUMERIC;            
            }

            qrCodeEncoder.QRCodeScale = scale;

            qrCodeEncoder.QRCodeVersion = version;

            if (errorCorrect == "L")
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L;
            else if (errorCorrect == "M")
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
            else if (errorCorrect == "Q")
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.Q;
            else if (errorCorrect == "H")
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.H;

            Image image;
            image = qrCodeEncoder.Encode(text);                      
            return image;
        }

        public static Image GenerateQRCode(string text)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();

            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            qrCodeEncoder.QRCodeScale = 4;
            qrCodeEncoder.QRCodeVersion = 7;
            qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;

            Image image;
            image = qrCodeEncoder.Encode(text);
            return image;
        }
    }
}
