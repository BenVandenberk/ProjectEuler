package main;

import java.util.ArrayList;

import org.apache.commons.lang3.time.StopWatch;

public class Main {

	public static void main(String[] args) {
		StopWatch s = new StopWatch();
		s.start();
		
		TotientPerm tp = new TotientPerm();
		int[] result = tp.run();
		System.out.println(String.format("Minimum voor n=%d, phi=%d: ratio=%f", result[0], result[1], (double)result[0]/result[1]));
		
		s.stop();
		System.out.println(s.getNanoTime() / 1000000);		
	}		

}
