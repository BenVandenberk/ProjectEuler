package main;

import java.util.List;

/**
 * Heb het algoritme uit de vorige opgave (PE76) gemakkelijk kunnen omvormen naar een algoritme dat deze opgave
 * oplost:
 * 
 * STAPPEN
 * 
 * [1] Genereer een hoop priemgetallen (achteraf bleek dat alle priemgetallen < 100 volstonden!)
 * [2] Zoek voor elk getal x dat je onderzoekt het grootste priemgetal p zodat p <= x
 * [3] Plug x en de index van p in de recursieve functie [aantalPriemSommen(int, int)]
 * 
 * UITLEG FUNCTIE
 * 
 * Neem f(x, y) als de functie die het aantal mogelijke priempartities berekent voor x waarbij enkel de priemgetallen
 * met index in het interval [0, y] gebruikt mogen worden.
 * 
 * In vijf speciale gevallen is de uitkomst van de functie triviaal:
 * 
 * [1] Als x = 1, dan f(x, y) = 0
 * [2] Als x = 0, dan f(x, y) = 1
 * [3] Als x < 0, dan f(x, y) = 0
 * [4] Als x = 2, dan f(x, y) = 1
 * [5] Als y = 0 dan f(x, y) = x % 2 == 0 ? 1 : 0
 * 
 * In alle andere gevallen is f(x, y) te vereenvoudigen:
 * 
 * f(x, y) = f(x - priemgetallen[y], y) + f(x - priemgetallen[y - 1], y - 1) + ... + f (x - priemgetallen[0], 0)
 * 
 * @author Ben
 *
 */
public class PrimeSummationsDriver {
	
	private List<Integer> priemgetallen;
	
	public PrimeSummationsDriver(int priemGrens) {
		PriemGenerator pg = new PriemGenerator(priemGrens);
		priemgetallen = pg.getPriemgetallen();
	}
	
	public int getAantalCombinatiesVoor(int getal) {		
		if (getal < 2) {
			return 0;
		}
		
		int priemIndex = -1;
		
		for (int i = 0; priemIndex == -1 && i < priemgetallen.size(); i++) {
			if (priemgetallen.get(i) > getal) {
				priemIndex = i - 1;
			}
		}
		
		return aantalPriemSommen(getal, priemIndex);
	}
	
	private int aantalPriemSommen(int x, int priemIndex) {
		int aantalSommen = 0;
		
		if (x == 1) {
			return 0;
		}
		if (x == 0) {
			return 1;
		}
		if (x < 0) {
			return 0;
		}
		if (x == 2) {
			return 1;
		}
		if (priemIndex == 0) {
			return x % 2 == 0 ? 1 : 0;
		}
		
		for(; priemIndex >= 0; priemIndex--) {
			aantalSommen += aantalPriemSommen(x - priemgetallen.get(priemIndex), priemIndex);
		}
		
		return aantalSommen;
	}

}
