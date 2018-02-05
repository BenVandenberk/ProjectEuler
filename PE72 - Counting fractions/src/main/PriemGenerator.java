package main;

import java.util.ArrayList;

public class PriemGenerator {

	private ArrayList<Integer> priemgetallen;
	private int max;
	
	public PriemGenerator(int max) {
		this.max = max;
		this.priemgetallen = new ArrayList<Integer>();
		generate();
	}
	
	public ArrayList<Integer> getPriemgetallen() {
		return priemgetallen;
	}
	
	private void generate() {
		boolean[] isComposite = new boolean[max + 1];
		
		for (int i = 2; i * i <= max; i++) {
			for (int j = i; i * j <= max; j++) {
				isComposite[i*j] = true;
			}
		}
		
		for (int i = 2; i <= max; i++) {
			if (!isComposite[i]) {
				priemgetallen.add(i);
			}
		}
	}
}

	