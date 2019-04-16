namespace P03_Heroes
{
    using System.Text;

    public class Item
    {
        public Item(int strength, int ability, int intelligence)
        {
            this.Strength = strength;
            this.Ability = ability;
            this.Intelligence = intelligence;
        }

        public int Strength { get; set; }

        public int Ability { get; set; }

        public int Intelligence { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("Item:");
            stringBuilder.AppendLine($"  * Strength: {this.Strength}");
            stringBuilder.AppendLine($"  * Ability: {this.Ability}");
            stringBuilder.Append($"  * Intelligence: {this.Intelligence}");
            return stringBuilder.ToString();
        }
    }
}
