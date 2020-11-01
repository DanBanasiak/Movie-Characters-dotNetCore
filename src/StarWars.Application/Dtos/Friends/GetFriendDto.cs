using System;

namespace StarWars.Application.Dtos.Friends
{
    public class GetFriendDto
    {
        public int CharacterId { get; set; }
        public string FriendName { get; set; }
    }
}