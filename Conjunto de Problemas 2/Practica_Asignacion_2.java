import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;

public class Practica_Asignacion_2 {

    static ArrayList<Item> lista = new ArrayList<>();

    static int Solve(int[] input, int cantidad){
        int MAX = Integer.MIN_VALUE;

        generarCombinaciones(input);
        Collections.sort(lista);

        for(int i = 0; i < lista.size(); ++i){
            int sumTotal = lista.get(i).Suma, k = cantidad-1;

            for(int j = 0; j < lista.size(); ++j ){
                if(k <= 0) break;
                if(i == j) continue;

                int comp = lista.get(i).compareIntervalos(lista.get(j));

                if(comp == 1){
                    lista.get(i).indices.add(lista.get(j));
                    sumTotal += lista.get(j).Suma;
                    k--;
                }
            }
           MAX = Math.max(MAX,sumTotal);
        }
        return MAX;
    }

    static void generarCombinaciones(int[] input){
        for(int i = 0; i < input.length; ++i){
            int sum = 0;
            for(int j = i; j < input.length; ++j){
                if(i == j){
                    lista.add(new Item(i,i,input[i]));
                    sum += input[i];
                }
                else{
                    lista.add(new Item(i,j,sum + input[j]));
                    sum += input[j];
                }
            }
        }
    }

    public static void main(String[] args) {
        Scanner cin = new Scanner(System.in);
        String buffer;
        buffer = cin.nextLine();

        String[] temp = buffer.split("\\ ");
        int N = Integer.parseInt(temp[0]);
        int K = Integer.parseInt(temp[1]);

        int[] input = new int[N];

        for(int i = 0; i < N; ++i){
            input[i] = Integer.parseInt(cin.next());
        }

        int Max = Solve(input, K);

        System.out.println(Max);
    }
}

class Item implements Comparable<Item> {

    public ArrayList<Item> indices = new ArrayList<>();
    public int hasta;
    public int desde;
    public int Suma;

    public Item(int desde, int hasta, int sum){
        this.desde = desde;
        this.hasta = hasta;
        this.Suma = sum;
        add(this);
    }

    public void add(Item o){
        this.indices.add(o);
    }

    public int compareIntervalos(Object o) {
        Item temp = (Item) o;
        int comp = 1;

        for(Item A : indices){
            if(A.desde == temp.desde){
                comp = 0;
                break;
            }

            if(A.hasta == temp.hasta){
                comp = 0;
                break;
            }

            if(A.desde == temp.hasta){
                comp = 0;
                break;
            }

            if(A.hasta == temp.desde){
                comp = 0;
                break;
            }

            if(A.desde < temp.desde && A.hasta > temp.hasta){
                comp = 0;
                break;
            }

            if(A.desde > temp.desde && temp.hasta > A.desde){
                comp = 0;
                break;
            }

            if(A.hasta > temp.desde && A.hasta < temp.hasta){
                comp = 0;
                break;
            }
        }
        return comp;
    }

    @Override public int compareTo(Item o) {
        return (o.Suma - this.Suma);
    }
}
