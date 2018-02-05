package main;

import org.apache.commons.lang3.time.StopWatch;

public class Main {

	public static void main(String[] args) {
		StopWatch s = new StopWatch();
		s.start();

		PrimeSummationsDriver psd = new PrimeSummationsDriver(100000);
		int max = 0;
		for (int i = 0; max <= 5000; i++) {
			max = psd.getAantalCombinatiesVoor(i);
			System.out.printf("%d kan op %d manieren geschreven worden als een som van priemgetallen\n", i, max);
		}

		s.stop();
		System.out.println(s.getNanoTime() / 1000000);
	}

}
