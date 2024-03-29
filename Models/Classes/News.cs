﻿using System.Collections.Generic;

namespace Models.Classes
{
    public class News : Feed
    {
        public News() { } // En tom konstuktor för att kunna serialisera/deserialisera objectet. 
        public News(string url, string name, int numberOfEpisodes, int timeInterval,
                string category, List<Episode> listOfEpisodes, string fileName) :
                base(url, name, numberOfEpisodes, timeInterval, category, listOfEpisodes, fileName) {}

        public override string Display()
        {
            return base.Display() + "Nyhet";
        }

    }
}
