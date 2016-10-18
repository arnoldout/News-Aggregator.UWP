using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsAggregator.Models
{
    class Story
    {
        private String title;
        private String description;
        private String uri;
        private List<String> categories = new List<string>();
        public Story(String title, String description, String uri, List<String> categories)
        {
            this.title = title;
            this.description = description;
            this.uri = uri;
            this.categories = categories;
        }
        public Story()
        {

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
