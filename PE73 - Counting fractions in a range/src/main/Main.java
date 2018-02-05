package main;

import org.apache.commons.lang3.time.StopWatch;

public class Main {

	public static void main(String[] args) {
		StopWatch s = new StopWatch();
		s.start();
		
		CountingFractionsDriver cfd = new CountingFractionsDriver(12000);
		cfd.run();
		System.out.println(cfd.getAantalBreuken());
		
		s.stop();
		System.out.println(s.getNanoTime() / 1000000);
	}

}
