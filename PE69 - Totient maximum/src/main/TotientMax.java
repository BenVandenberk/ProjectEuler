package main;

import java.util.ArrayList;

public class TotientMax {

	private PriemGenerator pg;
	private ArrayList<Integer> priemgetallen;
	private int[] bestePermutatie;
	private double maxRatio;

	public TotientMax(int tot) {
		pg = new PriemGenerator(tot);
		priemgetallen = pg.getPriemgetallen();
		bestePermutatie = new int[2];
		maxRatio = 0;
	}

	public int[] run() {
		check();
		return bestePermutatie;
	}

	private void check() {
		int currentPhi = 0;
		int currentPrime = 0;

		// Priemgetallen moet ik niet checken want phi(priemgetal) = priemgetal
		// - 1. De ratio n/phi(n) zal nooit maximaal zijn voor een priemgetal. Voor een priemgetal zal
		// de ratio immers altijd 1 benaderen
		for (int i = 0; i < priemgetallen.size() - 1; i++) {
			currentPrime = priemgetallen.get(i);
			if (++currentPrime != priemgetallen.get(i + 1)) {
				do {
					currentPhi = getPhi(currentPrime);					
								
					if ((double) currentPrime / currentPhi > maxRatio) {
						maxRatio = (double) currentPrime / currentPhi;
						bestePermutatie[0] = currentPrime;
						bestePermutatie[1] = currentPhi;
					}
				} while (++currentPrime != priemgetallen.get(i + 1));
			} else {
				continue;
			}
		}
	}

	/**
	 * Geeft de phi waarde van een bepaald getal terug
	 * 
	 * @param number
	 *            het getal waarvan je de phi waarde wil kennen
	 * @return phi(number)
	 */
	private int getPhi(int number) {
		double result = number;
		int currentPrime = 0;
		
		for (int i = 0; number > currentPrime && number > 1
				&& i < priemgetallen.size(); i++) {
			currentPrime = priemgetallen.get(i);
			if (number % currentPrime == 0) {			
				result *= (1.0 - (1.0 / currentPrime));
				number /= currentPrime;
			}
			while (number % currentPrime == 0) {
				number /= currentPrime;
			}
		}
		return (int) result;
	}
}
