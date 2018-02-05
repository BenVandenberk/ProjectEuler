package main;

import org.apache.commons.lang3.time.StopWatch;

public class Main {

	public static void main(String[] args) {
		StopWatch s = new StopWatch();
		s.start();		
		
		FactorialChainsDriver fcd = new FactorialChainsDriver();
		fcd.run();
		System.out.println(fcd.getAantalChainsVanZestig());
		
		s.stop();
		System.out.println(s.getNanoTime() / 1000000);
	}

}
