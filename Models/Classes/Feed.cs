﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Models.Interfaces;

namespace Models.Classes
{
    [XmlInclude(typeof(Podcast))]
    [XmlInclude(typeof(News))]
    public abstract class Feed : INameable
    {
        [XmlElement(Order = 1)]
        public string Name { get; set; }
        [XmlElement(Order = 2)]
        public int NumberOfEpisodes { get; set; }
        [XmlElement(Order = 3)]
        public int TimeInterval { get; set; }
        [XmlElement(Order = 4)]
        public string Category;
        [XmlElement(Order = 6, ElementName = "Episode")]
        public List<Episode> ListOfEpisodes;
        [XmlElement(Order = 5)]
        public string FileName { get; set; }
        public Feed()
        {
        }
        public Feed(string name, int numberOfEpisodes, int timeInterval, string category, 
            List<Episode> listOfEpisodes, string fileName)
        {
            Name = name;
            NumberOfEpisodes = numberOfEpisodes;
            TimeInterval = timeInterval;
            Category = category;
            ListOfEpisodes = listOfEpisodes;
            FileName = fileName;

        }

        public virtual string Display()
        {
            return "Det här är en: ";
        }

    }
}
