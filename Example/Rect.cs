using System;

namespace OutlineForm_Example
{
    public class Rect
    {
        private int _Left;
        private int _Right;
        private int _Top;
        private int _Bottom;

        public int Left
        {
            get
            {
                return _Left;
            }
            set
            {
                _Left = value;
                if (_Left < 0) _Left = 0;
            }
        }
        public int Right
        {
            get
            {
                return _Right;
            }
            set
            {
                _Right = value;
                if (_Right < 0) _Right = 0;
            }
        }
        public int Top
        {
            get
            {
                return _Top;
            }
            set
            {
                _Top = value;
                if (_Top < 0) _Top = 0;
            }
        }
        public int Bottom
        {
            get
            {
                return _Bottom;
            }
            set
            {
                _Bottom = value;
                if (_Bottom < 0) _Bottom = 0;
            }
        }

        public Rect()
        {
            Top = 0;
            Bottom = 0;
            Left = 0;
            Right = 0;
        }

        public Rect(Rect RectP)
        {

            if (RectP != null)
            {
                Top = RectP.Top;
                Bottom = RectP.Bottom;
                Left = RectP.Left;
                Right = RectP.Right;
            }
            else
            {
                Top = 0;
                Bottom = 0;
                Left = 0;
                Right = 0;
            }
        }

        public Rect(int TopP, int RightP, int BottomP, int LeftP)
        {
            Top = TopP;
            Bottom = BottomP;
            Left = LeftP;
            Right = RightP;
        }

        public Rect(int TopP, int RightandLeftP, int BottomP)
        {
            Top = TopP;
            Bottom = BottomP;
            Left = RightandLeftP;
            Right = RightandLeftP;
        }

        public Rect(int TopandBottomP, int RightandLeftP)
        {
            Top = TopandBottomP;
            Bottom = TopandBottomP;
            Left = RightandLeftP;
            Right = RightandLeftP;
        }

        public Rect(int RectP)
        {
            Top = RectP;
            Bottom = RectP;
            Left = RectP;
            Right = RectP;
        }


        /// <summary>
        /// Retorna la suma de Top y Bottom del Rect.
        /// </summary>
        /// <returns></returns>
        public int Height()
        {
            return Top + Bottom;
        }

        /// <summary>
        /// Retorna la suma de Left y Right del Rect.
        /// </summary>
        /// <returns></returns>
        public int Width()
        {
            return Left + Right;
        }



        //***********************************************
        //Metodos estaticos
        //***********************************************
        #region RECT_Metodos_Estaticos
        public static Rect Zero
        {
            get
            {
                return new Rect();
            }
        }

        public static bool isZero(Rect rectP)
        {
            return rectP.Left == 0 && rectP.Right == 0 && rectP.Bottom == 0 && rectP.Top == 0; 
        }
        #endregion




        public static bool Comparar(Rect RectP, Rect Rect2P)
        {
            if (RectP != null && Rect2P != null)
                return
                    RectP.Bottom == Rect2P.Bottom &&
                    RectP.Top == Rect2P.Top &&
                    RectP.Left == Rect2P.Left &&
                    RectP.Right == Rect2P.Right;
            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, Left) ? Left.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, Right) ? Right.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, Bottom) ? Bottom.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, Top) ? Top.GetHashCode() : 0);
                return hash;
            }
        }

        public override string ToString()
        {
            if (this == null)
                return "NULO";
            else
                return String.Format("Top:{0}, Right:{1}, Bottom:{2}, Left:{3}", Top, Right, Bottom, Left);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                return Comparar(this, (Rect)obj);
            }

        }

        public static bool operator ==(Rect RectP, Rect Rect2P)
        {
            if (Object.ReferenceEquals(null, RectP) || Object.ReferenceEquals(null, Rect2P)) return false;
            return Comparar(RectP, Rect2P);
        }

        public static bool operator !=(Rect RectP, Rect Rect2P)
        {
            if (Object.ReferenceEquals(null, RectP) || Object.ReferenceEquals(null, Rect2P)) return true;
            return !Comparar(RectP, Rect2P);
        }

        public static Rect operator ++(Rect RectP)
        {
            if (RectP != null)
            {
                Rect RectAux = new Rect(RectP);
                RectP.Left++;
                RectP.Right++;
                RectP.Bottom++;
                RectP.Top++;
                return RectAux;
            }
            return new Rect();
        }

        public static Rect operator --(Rect RectP)
        {
            if (RectP != null)
            {
                Rect RectAux = new Rect(RectP);
                RectP.Left--;
                RectP.Right--;
                RectP.Bottom--;
                RectP.Top--;
                return RectAux;
            }
            return new Rect();
        }

        public static Rect operator +(Rect RectP, Rect Rect2P)
        {
            return new Rect(
                RectP.Top + Rect2P.Top,
                RectP.Right + Rect2P.Right,
                RectP.Bottom + Rect2P.Bottom,
                RectP.Left + Rect2P.Left                
                );
        }
        public static Rect operator -(Rect RectP, Rect Rect2P)
        {
            return new Rect(
                RectP.Top - Rect2P.Top,
                RectP.Right - Rect2P.Right,
                RectP.Bottom - Rect2P.Bottom,
                RectP.Left - Rect2P.Left
                );
        }

        public static Rect operator +(Rect RectP, int valueP)
        {
            return new Rect(
                RectP.Top + valueP,
                RectP.Right + valueP,
                RectP.Bottom + valueP,
                RectP.Left + valueP
                );
        }
        public static Rect operator -(Rect RectP, int valueP)
        {
            return new Rect(
                RectP.Top - valueP,
                RectP.Right - valueP,
                RectP.Bottom - valueP,
                RectP.Left - valueP
                );
        }

    }
}
