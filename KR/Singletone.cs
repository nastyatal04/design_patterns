using System.Collections.Generic;
using System.Windows.Controls.Primitives;

namespace KR
{
    public class Singletone
    {
        private static Singletone? _instance = null;
        private static object _lock = new object();
        public ObservableData Airplanes = new ObservableData(new List<Airplane>());
        public int LastSelectedIndex { get; set; } = -1;
        private Singletone() { }
        public static Singletone GetInstance()
        {
            lock (_lock)
            {
                if (_instance == null)
                    _instance = new Singletone();
                return _instance;
            }
        }
    }
}
