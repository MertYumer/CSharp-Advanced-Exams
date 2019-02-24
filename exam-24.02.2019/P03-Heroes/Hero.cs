namespace P03_Heroes
{
    using System.Text;

    public class Hero
    {
        public Hero(string name, int level, Item item)
        {
            this.Name = name;
            this.Level = level;
            this.Item = item;
        }

        public string Name { get; set; }

        public int Level { get; set; }

        public Item Item { get; set; }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Hero: {Name} - {Level}lvl");
            stringBuilder.AppendLine("Item:");
            stringBuilder.AppendLine($"  * Strength: {this.Item.Strength}");
            stringBuilder.AppendLine($"  * Ability: {this.Item.Ability}");
            stringBuilder.Append($"  * Intelligence: {this.Item.Intelligence}");
            return stringBuilder.ToString();
        }
    }
}
