using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfTry.Model.Entities
{
    public class CharacteristicsName
    {
        public CharacteristicsName(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<ListOfCharacteristics> CharacteristicsList { get; set; } = null!;
    }
}
