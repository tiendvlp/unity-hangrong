using System.Collections.Generic;

public class HomeStreet{

	public int level;

	public Garage garage;

	public Home home;

	public class Garage {

		public int level;

		public List<string> cars;
	
	}

	public class Home {

		public int level;

		public int id;
	}
}
