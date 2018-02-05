package main;

import java.util.TreeSet;

/**
 * In [1] worden tripletten gegenereerd.
 * 
 * Uit a + b + c <= 1,500,000 volgt dat
 * n^2 - m^2 + 2nm + n^2 + m^2 <= 1,500,000 
 * Hieruit valt af te leiden dat de maximum waarde voor n 865 mag zijn (vandaar de lusconditie)
 * 
 * Bij het kijken naar de gegenereerde tripletten, bleek dat het algoritme niet alle tripletten genereerde. 
 * Ik ondervond dat wel alle primitieve tripletten gegenereerd werden (die waar a, b en c coprime zijn). 
 * Van de afgeleide tripletten werd maar een deel gegenereerd. In [2] wordt de rest van de tripletten gegenereerd.
 * Immers, als (a, b, c) een triplet is, dan is (na, nb, nc) dat ook.
 * 
 * Door een Set te gebruiken vermijd ik dubbels. 
 * 
 * @author Ben
 *
 */
public class PE75Driver {	
	
	private TreeSet<Triplet> pythTripletten;
	private int counters[];
	private int antwoord;
	
	public PE75Driver() {
		pythTripletten = new TreeSet<Triplet>();
		counters = new int[5000000];
		antwoord = 0;
	}
	
	public void run() {
		int a, b, c;
		
		// [1]
		for (int n = 2; n < 866; n++) {
			for (int m = 1; m < n; m++) {
				a = (n * n) - (m * m);
				b = 2 * n * m;
				c = (n * n) + (m * m);
				pythTripletten.add(new Triplet(a, b, c));
			}			
		}	
		
		Triplet[] originelen = pythTripletten.toArray(new Triplet[0]);
		int origSom = 0;
		
		// [2]
		for (int i = 0; i < originelen.length; i++) {		
			origSom = originelen[i].getSom();
			for (int factor = 2, som = origSom * 2; som <= 1500000; som = origSom * ++factor) {
				pythTripletten.add(originelen[i].getMultiple(factor));
			}
		}
		
		for (Triplet t : pythTripletten) {
			counters[t.getSom()]++;
		}
		
		for (int i = 1; i <= 1500000; i++) {
			antwoord += counters[i] == 1 ? 1 : 0;
		}

	}
	
	public int getAntwoord() {
		return antwoord;
	}
}


