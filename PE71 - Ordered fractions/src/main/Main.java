package main;

import org.apache.commons.lang3.time.StopWatch;

public class Main {

	public static void main(String[] args) {
		
		StopWatch s = new StopWatch();
		s.start();
		
		OrderedFracDriver ofd = new OrderedFracDriver(1000000);		
		ofd.run();
		
		System.out.printf("Antwoord: %d/%d = %f\n", ofd.getBestTeller(), ofd.getBestNoemer(), ofd.getBestRatio());
		
		s.stop();
		System.out.println(s.getNanoTime() / 1000000);
	}

}
