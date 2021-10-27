﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using BusinessLayer.Services;
using Models.Classes;



namespace RssApplication
{
    public partial class Form : System.Windows.Forms.Form
    {
        FeedService feedService;
        public Form()
        {
            InitializeComponent();
            feedService = new FeedService();

            cbTime.Items.Add("5");
            cbTime.Items.Add("15");
            cbTime.Items.Add("30");
            cbType.Items.Add("Nyhet");
            cbType.Items.Add("Podcast");
            cbSubscribeCategory.Items.Add("Historia");
            cbSubscribeCategory.Items.Add("Humor");
            DisplaySubscribeList();
        }

        private void DisplaySubscribeList()
        {
            lvSubscribe.Items.Clear();
            List<Feed> listOfFeeds = feedService.DisplayFeed();

            foreach (Feed item in listOfFeeds)
            {
                String[] row = {
                    item.FileName,
                    Convert.ToString(item.NumberOfEpisodes),
                    item.Name,
                    Convert.ToString(item.TimeInterval),
                    item.Category};

                ListViewItem List = new ListViewItem(row);
                lvSubscribe.Items.Add(List);
            }
            

        }

        private void DisplayEpisodeList(Feed feedObject) 
        {
            
            lbEpisode.Items.Clear();

            List<Episode> episodeList = null;
            episodeList = new List<Episode>();

            episodeList = feedObject.ListOfEpisodes;

            foreach (Episode episode in episodeList)
            {
                lbEpisode.Items.Add(episode.Title);

            }
            DisplaySubscribeList();
        }

        private void btnSubcribeAdd_Click(object sender, EventArgs e)
        {
            string url = tbUrl.Text;
            string name = tbSubscribeName.Text;
            int timeInterval = Convert.ToInt32(cbTime.SelectedItem);
            string category = Convert.ToString(cbSubscribeCategory.SelectedItem);
            string type = Convert.ToString(cbType.SelectedItem);

            feedService.CreateFeed(url, name, timeInterval, category, type);

            DisplaySubscribeList();


        }

        private void btnSubscribeChange_Click(object sender, EventArgs e)
        {
            tbEpisodeDescription.Text = "Testar tidsintervall";
        }

        private void lvSubscribe_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string fileName = "";
            var selectedRow = this.lvSubscribe.SelectedItems;
            //tbEpisodeDescription.Text = Convert.ToString(selectedRow);
            //var selectedIndex = this.lvSubscribe.SelectedItems;

            foreach (ListViewItem item in selectedRow)
            {
                //Hämtar filnamnet från kolumnen som är hidden
                fileName = item.SubItems[0].Text;
                //tbEpisodeDescription.Text = fileName;
            }

            Feed feedObject = feedService.CompareFeedObjects(fileName);
            DisplayEpisodeList(feedObject);

        }

    }
}
