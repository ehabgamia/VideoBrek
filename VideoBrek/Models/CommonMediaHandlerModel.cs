﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VideoBrek.Extensions;
using YoutubeExplode;
using YoutubeExplode.Models;
using YoutubeExplode.Models.MediaStreams;

namespace VideoBrek.Models
{
    public class MediaHandlerModel
    {
      static  YoutubeClient youtubeClient = new YoutubeClient();
        public class GetMediasModel
        {
            public int DisplayOrder { get; set; }
            public string CategoryName { get; set; }
            public List<AllMediaModel> Media { get; set; }
        }

        public static List<GetMediasModel> MyDataSourceAll { get; set; }

        public class AllMediaModel
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string CloudUrl { get; set; }
            public string ThumbURL { get; set; }
            public string AliasCloudUrl { get; set; }

            public string AliasThumbURL
            {
                //maxresdefault//sddefault
                get { return !string.IsNullOrEmpty(CloudUrl) ? "https://img.youtube.com/vi/" + CloudUrl+ "/maxresdefault.jpg" : "https://www.prioritysoftware.com/wp-content/uploads/2015/02/xno-image.png.pagespeed.ic.TALCyIr8tu.webp"; }
            }

            //public string AliasCloudUrl
            //{
            //    get { return !CloudUrl.Contains("https://www.youtube.com/") ? "https://www.youtube.com/" + CloudUrl : CloudUrl; }
            //}
            public bool IsAddedToMyList { get; set; }
        }

        public class SearchModel
        {
            public string SearchString { get; set; }
        }

        public class AddMyListModel
        {
            public string UserID { get; set; }
            public string MediaID { get; set; }
        }

        public class UserSettingsModel
        {
            public string userID { get; set; }
        }

        public class SearchMediaModel
        {
            public int MediaID { get; set; }
            public string Title { get; set; }
            public string MediaDesc { get; set; }
            public string ClickURL { get; set; }
            public string Thumbnail { get; set; }
            public int EpisodeID { get; set; }
            public int SeasonID { get; set; }

            public string AliasThumbURL
            {
                //get { return "http://graceanointing.org" + ThumbURL; }
                get { return !string.IsNullOrEmpty(ClickURL) ? "https://img.youtube.com/vi/" + YouTubeVideoIdExtension.YouTubeVideoIdFromUrl(ClickURL) + "/maxresdefault.jpg" : "https://www.prioritysoftware.com/wp-content/uploads/2015/02/xno-image.png.pagespeed.ic.TALCyIr8tu.webp"; }
            }

            public string AliasCloudUrl
            {
                get { return ClickURL; }

            }
        }

        public static async Task<Video> GetVideoAsync(string Url)
        {
            Video resp = null;
            youtubeClient = new YoutubeClient();
            try
            {
                resp = await youtubeClient.GetVideoAsync(Url);
                return resp;
            }
            catch (Exception ex)
            {
                //Crashes.TrackError(ex);
                return resp;
            }
        }

        public static async Task<MediaStreamInfoSet> GetVideoMediaStreamInfosAsync(string Url)
        {
            youtubeClient = new YoutubeClient();
            MediaStreamInfoSet resp = null;
            try
            {
                resp = await youtubeClient.GetVideoMediaStreamInfosAsync(Url);
                return resp;
            }
            catch (Exception ex)
            {
                //Crashes.TrackError(ex);
                return resp;
            }
        }
    }
}