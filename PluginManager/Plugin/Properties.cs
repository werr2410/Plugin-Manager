namespace PManager {
    partial class Plugin {
        public string Name {
            set {
                if(value != "")
                    throw new FormatException("Name plugin never be empty");

                _name = value;
            }

            get => _name;
        }

        public string Description {
            set {
                if(value.Length <= 200) 
                    throw new FormatException("Description plugin small that 150");

                _description = Description;
            }

            get => _description;
        }

        protected DateTime CreationDate {
            set {
                if(value > DateTime.Now)
                    throw new FormatException("Creation time biggest that now");

                _creationDate = value;
            }
        }

        public DateTime CreationDateTime {
            get => _creationDate;
        }
        
        private int CountElement {
            get => 4;
        }

        public static string Extension {
            get => ".pmdata";
        }
    }
}