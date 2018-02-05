package main;

import org.apache.commons.lang3.time.StopWatch;

public class Main {

	public static void main(String[] args) {
		StopWatch s = new StopWatch();
		s.start();

		SummationCounter sc = new SummationCounter(100);
		sc.run();
		System.out.printf("%d\n", sc.getAantalSommen());

		s.stop();
		System.out.println(s.getNanoTime() / 1000000);
	}

}
