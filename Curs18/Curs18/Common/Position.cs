namespace Curs18.Common
{
    public class Position : AbstractSubject
    {
        private int x;
        private int y;

        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
                OnPropertyChanged("X");
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
                OnPropertyChanged("Y");
            }
        }
    }
}