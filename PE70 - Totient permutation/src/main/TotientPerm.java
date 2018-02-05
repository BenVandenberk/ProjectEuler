package main;

import java.util.ArrayList;
import java.util.Arrays;

public class TotientPerm {

	private PriemGenerator pg;
	private ArrayList<Integer> priemgetallen;
	private int[] bestePermutatie;
	private double minRatio;

	public TotientPerm() {
		pg = new PriemGenerator(10000000);
		priemgetallen = pg.getPriemgetallen();
		bestePermutatie = new int[2];
		minRatio = 1000;
	}

	public int[] run() {
		check();
		return bestePermutatie;
	}

	private void check() {
		int currentPhi = 0;
		int currentPrime = 0;

		// Priemgetallen moet ik niet checken want phi(priemgetal) = priemgetal - 1. Linkerkant van vorige
		// vergelijking kan nooit een permutatie zijn van de rechterkant. Onderstaande methode is 600 ms sneller
		// dan met een binarySearch te zoeken of de loopvariabele een priemgetal is.
		//
		// Wat er gebeurt: lijst van priemgetallen overlopen en alleen de getallen die tussen twee priemgetallen
		// liggen, checken
		for (int i = 0; i < priemgetallen.size() - 1; i++) {
			currentPrime = priemgetallen.get(i);
			if (++currentPrime != priemgetallen.get(i + 1)) {
				do {
					currentPhi = getPhi(currentPrime); // getPhi geeft 0 terug als de method voortijdig gestopt
													   // is vanwege een slechte verhouding n/phi(n)
					if (currentPhi == 0) {
						continue;
					}
					if (isPerm(currentPhi, currentPrime)) {
						if ((double) currentPrime / currentPhi < minRatio) {
							minRatio = (double) currentPrime / currentPhi;
							bestePermutatie[0] = currentPrime;
							bestePermutatie[1] = currentPhi;
						}
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
	 * @param number het getal waarvan je de phi waarde wil kennen
	 * @return 0 als de ratio n / phi(n) te hoog is om een oplossing te kunnen zijn (> minRatio). Returns
	 * phi(number) als de ratio < minRatio 
	 */
	private int getPhi(int number) {
		int origNumber = number;
		double result = number;
		int currentPrime = 0;
		for (int i = 0; number > currentPrime && number > 1
				&& i < priemgetallen.size(); i++) {
			currentPrime = priemgetallen.get(i);
			if (number % currentPrime == 0) {
				result *= (1.0 - (1.0 / currentPrime));
				if ((double)origNumber / result > minRatio) {
					return 0;
				}
				number /= currentPrime;
			}
			while (number % currentPrime == 0) {
				number /= currentPrime;
			}
		}
		return (int) result;
	}

	private boolean isPerm(int first, int second) {
		char[] firstArr = Integer.toString(first).toCharArray();
		char[] secondArr = Integer.toString(second).toCharArray();
		boolean isPerm = true;
		if (firstArr.length != secondArr.length) {
			return false;
		}
		Arrays.sort(firstArr);
		Arrays.sort(secondArr);
		for (int i = 0; i < firstArr.length && isPerm; i++) {
			if (firstArr[i] != secondArr[i]) {
				isPerm = false;
			}
		}
		return isPerm;
	}

}
