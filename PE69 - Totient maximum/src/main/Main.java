package main;

import org.apache.commons.lang3.time.StopWatch;

public class Main {

	public static void main(String[] args) {
		
		StopWatch s = new StopWatch();
		s.start();

		TotientMax tm = new TotientMax(1000000);
		int[] result = tm.run();		
		
		s.stop();

		System.out.printf("Maximum n/phi voor n = %d, phi(n) = %d - ratio = %f\n", result[0], result[1], (double)result[0]/result[1]);
		System.out.println(s.getNanoTime() / 1000000);

	}
}

// OUDE, TRAGERE CODE
//
//int[] numberOfRelativePrimes = new int[1000001];
//for (int i = 1; i < numberOfRelativePrimes.length; i++) {
//	numberOfRelativePrimes[i] = i - 1;
//}
//
//PriemGenerator pg = new PriemGenerator(500000);
//ArrayList<Integer> priemgetallen = pg.getPriemgetallen();
//
//int[] counter = new int[500000];
//int priem = 0;
//boolean eerste = true;
//
//for (int getal = 2; getal <= 1000000; getal++) {
//	if (getal % 2 != 0) {
//		if (Collections.binarySearch(priemgetallen, getal) >= 0) {
//			continue;
//		}
//	}
//	eerste = true;
//	for (int priemIndex = 0; priemIndex < priemgetallen.size(); priemIndex++) {
//		priem = priemgetallen.get(priemIndex);
//		if (priem > getal / 2) {
//			break;
//		}
//		if (getal % priem == 0) {
//			numberOfRelativePrimes[getal] -= counter[priem];
//			if (eerste) {
//				counter[priem]++;						
//				eerste = false;
//			}
//		}
//	}
//}
//
//double max = 0;
//int index = -1;
//for (int i = 10000; i < numberOfRelativePrimes.length; i++) {
//	if ((double) i / numberOfRelativePrimes[i] > max) {
//		max = (double) i / numberOfRelativePrimes[i];
//		index = i;
//	}
//}
