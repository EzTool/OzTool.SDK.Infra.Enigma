using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace UT.OzTool.SDK.Infra.Enigma._Models
{
    public class Model
    {
        public string ID { get; set; }
        public List<string> Addressies { get; set; }
        public ObservableCollection<EditLogInfo> EditLogs { get; set; }

    }

    public class EditLogInfo
    {
        public string ID { get; set; }

        public override bool Equals(object obj)
        {
            // 正常來說覆寫 Equals() 應該也要覆寫 GetHashCode()
            // 一般的情況，如果只是要比較兩個 Customer 物件是否相同，
            // 不建議覆寫 Equals 與 GetHashCode()，
            // 而是使用 IEqualityComparer<T> 來定義怎麼比較 T 是否相等
            if (!(obj is EditLogInfo input))
            {
                return false;
            }
            else
            {
                return this.ID == input.ID;
            }
        }
    }
}
