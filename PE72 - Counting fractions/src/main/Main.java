package main;

import org.apache.commons.lang3.time.StopWatch;

public class Main {

	public static void main(String[] args) {
		StopWatch s = new StopWatch();
		s.start();
		
		Driver d = new Driver();
		System.out.println(d.getNumberOfFractions());
		
		s.stop();
		System.out.println(s.getNanoTime() / 1000000);
	}

}
