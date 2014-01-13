using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LegeDoos.LDM
{
    /// <summary>
    /// Class to handle loading and clearing of images in the background
    /// </summary>
    internal class ImageCacheHandler
    {
        FileManager m_FileManager = null;

        public ImageCacheHandler(FileManager _FileManager)
        {
            m_FileManager = _FileManager;
        }

        public void Run()
        {
            if (!GlobalSettings.theSettings.DisableImageCache)
            {
                DoCacheImages();
            }
        }

        /// <summary>
        /// Actually cache and dispose the images
        /// </summary>
        public void DoCacheImages()
        {
            if (m_FileManager == null)
                return;

            foreach (TheFile f in ImagesToCache())
            {
                f.Image();
            }

            /*
             * Futute use
            foreach (TheFile f in ImagesToClear())
            {
                f.ClearImage();
            }
             */

        }

        /// <summary>
        /// Get a list of images to cache
        /// </summary>
        /// <returns></returns>
        private List<TheFile> ImagesToCache()
        {
            return m_FileManager.TheFileList;
        }

        /// <summary>
        /// Get a list of images to dispose
        /// </summary>
        /// <returns></returns>
        private List<TheFile> ImagesToClear()
        {
            return new List<TheFile>();
        }
    }

    /// <summary>
    /// Execute image handler in thread
    /// </summary>
    internal class ImageCacheThreading
    {
        private FileManager m_FileManager = null;
        private Thread m_ImageCacheThread = null;

        public ImageCacheThreading(FileManager _FileManager)
        {
            m_FileManager = _FileManager;
        }

        public void StartThread()
        {
            ImageCacheHandler oHandler = new ImageCacheHandler(m_FileManager);
            m_ImageCacheThread = new Thread(new ThreadStart(oHandler.Run));
            m_ImageCacheThread.Start();
        }
        
    }
}
