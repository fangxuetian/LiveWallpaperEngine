﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LiveWallpaperEngineRemoteWebRender
{

    public class HostInfo
    {
        public bool Initlized { get; set; }
    }

    public class WebRenderAPI
    {
        private string _baseUrl;

        public WebRenderAPI(string url)
        {
            _baseUrl = url;
        }

        public async Task<HostInfo> GetInfo()
        {
            try
            {
                HttpClient client = new HttpClient();
                var json = await client.GetStringAsync(_baseUrl + "/getInfo");
                var result = JsonConvert.DeserializeObject<HostInfo>(json);
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<Dictionary<int, IntPtr>> GetHosts(int[] screenIndexs)
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                foreach (var i in screenIndexs)
                {
                    sb.AppendFormat("{0},", i);
                }
                HttpClient client = new HttpClient();
                var json = await client.GetStringAsync(_baseUrl + "/getHosts?screenIndexs=" + sb.ToString());
                var result = JsonConvert.DeserializeObject<Dictionary<int, IntPtr>>(json);
                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
