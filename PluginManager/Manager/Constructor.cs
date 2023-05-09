namespace PManager {
    partial class Manager {
        public Manager() {
            file = new ManagerFile(StandartPath);
        }
        
        public Manager(string path) {
            file = new ManagerFile(path);
        }
    }
}