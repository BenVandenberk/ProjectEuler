package main;

public class OrderedFracDriver {
	
	final double TE_BENADEREN = (double) 3 / 7;
	final int GRENS;
	
	double bestRatio = 0;
	int bestTeller = 0;
	int bestNoemer = 0;

	public OrderedFracDriver(int tot) {
		GRENS = tot;
	}	
	
	public double getBestRatio() {
		return bestRatio;
	}

	public int getBestTeller() {
		return bestTeller;
	}

	public int getBestNoemer() {
		return bestNoemer;
	}

	public void run() {
		int teller;
		
		for (int noemer = 8; noemer <= GRENS; noemer++) {
			teller = zoekTellerVoor(noemer);
			while ((double)teller / noemer > TE_BENADEREN) {
				teller--;
			}
			while (!areRelativePrimes(teller, noemer)) {
				teller--;
			}
			if ((double)teller / noemer > bestRatio) {
				bestRatio = (double)teller / noemer;
				bestTeller = teller;
				bestNoemer = noemer;
			}
			
		}		
	}
	
	private int zoekTellerVoor(int noemer) {
		int bovengrensTeller = noemer / 2;
		int ondergrensTeller = noemer * 2 / 5;
		int zoekTeller = ondergrensTeller;

		while (bovengrensTeller - ondergrensTeller > 1) {
			if ((double) zoekTeller / noemer < TE_BENADEREN) {
				ondergrensTeller = zoekTeller;
				zoekTeller += ((bovengrensTeller - zoekTeller) / 2);
			} else {
				bovengrensTeller = zoekTeller;
				zoekTeller -= ((zoekTeller - ondergrensTeller) / 2);
			}
		}

		return zoekTeller;
	}

	private boolean areRelativePrimes(int grootste, int kleinste) {
		int temp;

		while (kleinste > 0) {
			grootste %= kleinste;
			temp = grootste;
			grootste = kleinste;
			kleinste = temp;
		}
		
		return grootste == 1;
	}
}
