using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace NewsAggregator.Models
{
    class Story
    {
        private String title;
        private String description;
        private String uri;
        private List<String> categories = new List<string>();
        private Uri imgUri;
        public Story(String title, String description, String uri, List<String> categories, String imgUri)
        {
            this.title = title;
            if (!description.Equals(""))
            {
                this.description = description;
            }
            else
            {
                this.description = "No Description Available";
            }
            this.uri = uri;
            this.categories = categories;
            this.imgUri = new Uri(imgUri);
        }
        public Story()
        {

        }
        public Uri ImgUri
        {
            get
            {
                return imgUri;
            }

            set
            {
                imgUri = value;
            }
        }
        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
            }
        }

        public string Uri
        {
            get
            {
                return uri;
            }

            set
            {
                uri = value;
            }
        }

        public List<string> Categories
        {
            get
            {
                return categories;
            }

            set
            {
                categories = value;
            }
        }
    }
}
