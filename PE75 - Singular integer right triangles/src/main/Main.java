package main;

import org.apache.commons.lang3.time.StopWatch;

public class Main {

	public static void main(String[] args) {
		StopWatch s = new StopWatch();
		s.start();
		
		PE75Driver PE75D = new PE75Driver();
		PE75D.run();
		System.out.println(PE75D.getAntwoord());
		
		s.stop();
		System.out.println(s.getNanoTime() / 1000000);	
	}

}
