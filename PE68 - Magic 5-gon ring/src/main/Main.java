package main;

import java.util.ArrayList;

import org.apache.commons.lang3.time.StopWatch;

import hulp.Combinaties;
import hulp.Helper;
import hulp.Permutaties;

public class Main {
	
	public static void main(String[] args) {
		StopWatch s = new StopWatch();
		s.start();
		
		Combinaties c = new Combinaties(10, 5);
		int[][] combinaties = c.getCombinaties();
		
		ArrayList<int[]> allePermutaties = new ArrayList<int[]>();
		
		for (int[] combinatie : combinaties) {
			int max = 0;
			int index = -1;
			for (int i = 0; i < combinatie.length; i++) {
				if (combinatie[i] > max) {
					max = combinatie[i];
					index = i;
				}				
			}
			int[] tePermuteren = Helper.removeNumber(combinatie, index);
			Permutaties p = new Permutaties(tePermuteren);
			
			int[][] permutaties = p.getPermutaties();
			for (int i = 0; i < permutaties.length; i++) {
				permutaties[i] = Helper.combineer(permutaties[i], combinatie[index]);
			}
			
			for (int[] permutatie : permutaties) {
				allePermutaties.add(permutatie);
			}
		}
		
		for (int i = allePermutaties.size() - 1; i >= 0; i--) {
			if (!alleSommenVerschillend(allePermutaties.get(i))) {
				allePermutaties.remove(i);
			}
		}
		
		ArrayList<String> winners = new ArrayList<String>();
		
		for (int[] innerSet : allePermutaties) {
			Permutaties p = new Permutaties(getComplement(innerSet));
			int[][] outerSets = p.getPermutaties();
			for (int[] outerSet : outerSets) {
				if (isMagic5GonRing(innerSet, outerSet)) {
					winners.add(magic5GonRingWord(innerSet, outerSet));
				}
			}
		}
		
		s.stop();
		
		for (String winner : winners) {
			System.out.println(winner);
		}
		
		System.out.printf("\nElapsed time: %d ms", s.getNanoTime() / 1000000);
	}
	
	private static boolean isMagic5GonRing(int[] innerSet, int[] outerSet) {
		int som = outerSet[outerSet.length - 1] + innerSet[0] + innerSet[innerSet.length - 1];
		for (int innerIndex = 0, outerIndex = 0; innerIndex < innerSet.length - 1 && outerIndex < outerSet.length; outerIndex++, innerIndex++) {
			if (som != outerSet[outerIndex] + innerSet[innerIndex] + innerSet[innerIndex + 1]) {
				return false;
			}
		}
		return true;
	}
	
	private static String magic5GonRingWord(int[] inner, int[] outer) {
		int min = 1000;
		int minIndex = -1;
		for (int i = 0; i < outer.length; i++) {
			if (outer[i] < min) {
				min = outer[i];
				minIndex = i;
			}
		}
		
		String word = "";
		for (int outerIndex = minIndex, innerIndex = outerIndex; outerIndex < outer.length; outerIndex++, innerIndex++) {
			word += String.format("%d%d", outer[outerIndex], inner[innerIndex]);
			if (innerIndex == inner.length - 1) {
				word += inner[0];
			} else {
				word += inner[innerIndex + 1];
			}
		}
		
		for (int i = 0; i < minIndex; i++) {
			word += String.format("%d%d%d", outer[i], inner[i], inner[i + 1]);
		}
		
		return word;
	}
	
	private static int[] getComplement(int[] input) {
		int[] complement = new int[5];
		int index = 0;
		for (int i = 1; i <= 10; i++) {
			if (!contains(input, i)) {
				complement[index++] = i;
			}
		}
		return complement;
	}
	
	private static boolean contains(int[] set, int number) {
		for (int i : set) {
			if (i == number) {
				return true;
			}
		}
		return false;
	}
	
	private static boolean alleSommenVerschillend(int[] input) {
		ArrayList<Integer> sommen = new ArrayList<Integer>();
		sommen.add(input[0] + input[input.length - 1]);
		for (int i = 0; i < input.length - 1; i++) {
			int som = input[i] + input[i + 1];
			if (sommen.contains(som)) {
				return false;
			} else {
				sommen.add(som);
			}
		}
		return true;
	}

}
