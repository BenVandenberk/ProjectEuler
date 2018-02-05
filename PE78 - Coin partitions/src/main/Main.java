package main;

import java.math.BigInteger;

import org.apache.commons.lang3.time.StopWatch;

public class Main {

	public static void main(String[] args) {
		StopWatch s = new StopWatch();
		s.start();

		boolean isDivisibleByAMillion = false;
		int antwoord = 0;
//		SummationCounter sc = new SummationCounter(10);
//		sc.run();
		SummationCounter sc = new SummationCounter(1);
		BigInteger aMillion = new BigInteger("1000000");
		
		for (int i = 1; !isDivisibleByAMillion; i++) {
			sc.setGetal(i);
			sc.run();
			System.out.printf("%d - %d\n", i, sc.getAantalSommen());
			isDivisibleByAMillion = sc.getAantalSommen().mod(aMillion) == BigInteger.ZERO ? true : false;
			antwoord = isDivisibleByAMillion ? i : 0;
		}
		
		System.out.println(antwoord);

		s.stop();
		System.out.println(s.getNanoTime() / 1000000);
	}

}
