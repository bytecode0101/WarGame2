using System.ComponentModel;

namespace Curs18.Common
{
    /// <summary>
    /// Observer Pattern
    /// </summary>
    public class AbstractSubject : INotifyPropertyChanged
    {
        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        /// <summary>
        /// The name of the property that has changed
        /// </summary>
        /// <param name="propertyName"></param>
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
