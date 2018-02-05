package main;

import java.util.ArrayList;

public class Driver {
	
	private ArrayList<Integer> priemgetallen;
	
	public Driver() {
		PriemGenerator pg = new PriemGenerator(1000000);
		priemgetallen = pg.getPriemgetallen();
	}
	
	public Long getNumberOfFractions() {
		Long nrOfFractions = 0L;
		for (int i = 2; i <= 1000000; i++) {
			nrOfFractions += getPhi(i);
		}
		return nrOfFractions;
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
				number /= currentPrime;
			}
			while (number % currentPrime == 0) {
				number /= currentPrime;
			}
		}
		return (int) result;
	}

}
