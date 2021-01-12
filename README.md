## Requirement

- Track the games and the outcomes.
- Multiple competitors.
- Schedule games.
- Loosing eliminates the player.
- Last standing wins.

## Unknown variables

1. How many players?
2. Uneven player scenario or a lot of players?
3. Who plays who, random or organized?
4. Store the exact scores or just who won?
5. Where will the data be stored?
6. Particular prices?
7. How many users, access of users?
8. What kind of front end?
9. Reporting system?
10. Should the system contact the users about the upcoming games?

## Answers:

1. Application should be able to handle multiple players.
2. In case of uneven players, the extra players go to the next round automatically.
3. Random matching.
4. Simple score storing.
5. SQL server and txt file.
6. The app must handle an entry fee, the price must be able to distribute among multiple options and it should be based on percentage.
7. Many users, no levels, but the competitors cant access the application. Instead they handle everything via email.
8. WPF application that can be migrated to website.
9. Simple report. Must specify who won and the end score. It mus be emailed to the competitors and the administrator.
10. Yes, it should email when the players are going to play.
