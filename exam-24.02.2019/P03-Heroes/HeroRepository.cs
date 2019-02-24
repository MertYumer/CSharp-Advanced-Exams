namespace P03_Heroes
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class HeroRepository
    {
        private List<Hero> data;

        public HeroRepository()
        {
            this.data = new List<Hero>();
        }

        public int Count => this.data.Count;

        public void Add(Hero hero)
        {
            this.data.Add(hero);
        }

        public void Remove(string name)
        {
            int index = this.data.FindIndex(h => h.Name == name);

            if (index != -1)
            {
                this.data.RemoveAt(index);
            }
        }

        public Hero GetHeroWithHighestStrength()
        {
            Hero hero = this.data.OrderByDescending(h => h.Item.Strength).First();
            return hero;
        }

        public Hero GetHeroWithHighestAbility()
        {
            Hero hero = this.data.OrderByDescending(h => h.Item.Ability).First();
            return hero;
        }

        public Hero GetHeroWithHighestIntelligence()
        {
            Hero hero = this.data.OrderByDescending(h => h.Item.Intelligence).First();
            return hero;
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();

            foreach (var hero in this.data)
            {
                stringBuilder.AppendLine($"Hero: {hero.Name} - {hero.Level}lvl");
                stringBuilder.AppendLine("Item:");
                stringBuilder.AppendLine($"  * Strength: {hero.Item.Strength}");
                stringBuilder.AppendLine($"  * Ability: {hero.Item.Ability}");
                stringBuilder.Append($"  * Intelligence: {hero.Item.Intelligence}");
            }

            return stringBuilder.ToString();
        }
    }
}
