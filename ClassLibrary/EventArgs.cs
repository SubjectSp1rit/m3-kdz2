namespace ClassLibrary
{
    /// <summary>
    /// Предоставляет данные для события
    /// </summary>
    public class EnhancedEventArgs : EventArgs
    {
        /// <summary>
        /// Получает дату и время, когда произошло изменение.
        /// </summary>
        public DateTime UpdateTime { get; }

        public EnhancedEventArgs(DateTime updateTime)
        {
            UpdateTime = updateTime;
        }
    }
}
