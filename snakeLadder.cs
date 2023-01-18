// snake and ladder
using System;

class SnakeLadder {
    int UC_2_roll_die(){
        Random rndm = new Random();
        int dice_num = rndm.Next(1,7);
        return dice_num;
    }
    
    int UC_3_do_action(int curr_pos, int dice_num){
        Random rndm = new Random();
        int option = rndm.Next(0,3);
        int new_pos = curr_pos;
        switch(option){
            case 0:
                Console.WriteLine("Option: No play, You are at same position: " + new_pos);
                break;
            case 1:
                new_pos += dice_num;
                if (new_pos > 100){
                    new_pos = curr_pos;
                }
                Console.WriteLine("Option: Ladder, You are at position: " + new_pos);
                break;
            case 2:
                new_pos -= dice_num;
                if (new_pos < 0){
                    new_pos = 0;
                }
                Console.WriteLine("Option: Snake, You are at position: " + new_pos);
                break;
            default:
                Console.WriteLine("not valid option.");
                break;
        }
        
        return new_pos;
        
    }
    
    int two_player_UC_3_do_action(int curr_pos, int dice_num){
        Random rndm = new Random();
        int option = rndm.Next(0,3);
        int new_pos = curr_pos;
        int do_again = 0;
        do{
            if (option == 0){
                Console.WriteLine("     Option: No play, You are at same position: " + new_pos);
                do_again = 0;
            }
            
            else if (option == 1){
                new_pos += dice_num;
                if (new_pos > 100){
                    new_pos -= dice_num;
                }
                Console.WriteLine("     Option: Ladder, You are at position: " + new_pos);
                Console.WriteLine("     You get another roll.");
                
                option = rndm.Next(0,3);
                do_again = 1;
            }
            
            else if (option == 2){
                new_pos -= dice_num;
                if (new_pos < 0){
                    new_pos = 0;
                }
                Console.WriteLine("     Option: Snake, You are at position: " + new_pos);
                do_again = 0;
            }

        }while(do_again == 1);
        
        return new_pos;
        
    }
    
    public void UC_4_repeat_till_win(int curr_pos){
        int num_times_die_roll = 0;
        
        while(curr_pos != 100){
            int dice_num = UC_2_roll_die();
            num_times_die_roll += 1;
            curr_pos = UC_3_do_action(curr_pos, dice_num);
        }
        
        Console.WriteLine("No. of die rolls taken to win: " + num_times_die_roll);
    }
    
    public void UC_7_two_player_game(){
        int win = 0;
        int P1_curr_pos = 0;
        int P2_curr_pos = 0;
        
        while(win == 0){
            Console.WriteLine("PLAYER 1: ");
            
            int dice_num = UC_2_roll_die();
            P1_curr_pos = two_player_UC_3_do_action(P1_curr_pos, dice_num);
            
            if (P1_curr_pos == 100){
                win = 1;
                break;
            }
            
            Console.WriteLine("PLAYER 2: ");
            dice_num = UC_2_roll_die();
            P2_curr_pos = two_player_UC_3_do_action(P2_curr_pos, dice_num);
            
            if (P2_curr_pos == 100){
                win = 2;
                break;
            }
        }
        
        Console.WriteLine("-------------------------------------------------------------------");
        switch(win){
            case 1:
                Console.WriteLine("Player 1 WON");
                break;
            case 2:
                Console.WriteLine("Player 2 WON");
                break;
            default:
                Console.WriteLine("not valid");
                break;
        }
    }
}
class snake_ladder_play {
    static void Main() {
        Console.WriteLine("Welcome to snake and ladder");
        SnakeLadder snake_ladder = new SnakeLadder();
        
        snake_ladder.UC_4_repeat_till_win(0);
        snake_ladder.UC_7_two_player_game();
        
    }
}