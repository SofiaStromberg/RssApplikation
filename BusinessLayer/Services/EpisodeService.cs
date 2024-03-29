﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Repositories;
using Models.Classes;

namespace BusinessLayer.Services
{
    
    public class EpisodeService
    {
        IEpisodeRepository<Episode> episodeRepository;

        public EpisodeService()
        {

            episodeRepository = new EpisodeRepository();
        }

        public async Task<List<Episode>> GetListOfEpisodesAsync(string url)
        {
            List<Episode> listOfEpisodes = new List<Episode>();

            try
            {
                listOfEpisodes = await episodeRepository.GetCurrentEpisodesAsync(url);

                return listOfEpisodes;

            } catch (Exception) { }

            return listOfEpisodes;
        }
        
        public int GetNumberOfEpisodes(List<Episode> listOfEpisodes)
        {
            int counter = 0;

            foreach(Episode episode in listOfEpisodes)
            {
                counter++;
            }

            return counter;
        }
    }
}

