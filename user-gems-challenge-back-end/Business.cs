using System;
using System.Collections.Generic;
using System.Linq;
using User_gems_challenge.IBusiness;
using User_gems_challenge.Dto;
using User_gems_challenge.Entity;
using User_gems_challenge.Repository;
using User_gems_challenge.Business.Mappers;
using Utils.Queries;
using IRepository;
namespace User_gems_challenge.Business
{
    public class Business : IBusiness.IBusiness
    {
        private readonly Mapper mapper = new Mapper();

        IRepository<WeatherForecast> repository;

        public Business(string connection, IRepository<WeatherForecast> _repository)
        {
            repository = _repository;
        }


        /*public List<ChatDto> GetAllChat(string title)
        {
            IEnumerable<Chat> chats = chatRepositoryCustom.GetChats(title);

            List<ChatDto> chat = mapper.ListEntityToListDto(chats);
            return chat;
        }

        public ChatDto GetChatById(int Id)
        {
            if (Id == 0)
            {
                throw new Exception("Parametro nao foi achado");
            }
            object parameters = new { Id };
            Chat chat = chatRepository.GetData("", parameters).FirstOrDefault();

            return mapper.EntityToDto(chat);
        }

        public int UpdateChat(ChatDto Chat)
        {
            if (Chat == null)
            {
                throw new Exception("Parametro nao pode ser nulo");
            }
            return chatRepository.InstertOrUpdate(mapper.DtoToEntity(Chat), new { DoacaoId = Chat.Id });
        }


        public void DeleteChatById(int Id)
        {
            if (Id == 0)
            {
                throw new Exception("Parametro nao pode ser nulo");
            }
            chatMessageRepository.Remove(new { Chat_id = Id });
            chatRepository.Remove(new { Id });
        }


        public int InsertChat(List<ChatDto> Chat)
        {
            if (Chat == null)
            {
                throw new Exception("Parametro nao pode ser nulo");
            }
            return chatRepository.Add(mapper.ListDtoToListEntity(Chat));
        }
        public int InsertChatMessage(ChatMessagesDto Message)
        {
            if (Message == null)
            {
                throw new Exception("Parametro nao pode ser nulo");
            }
            return chatMessageRepository.Add(chatMessagemapper.DtoToEntity(Message));
        }
        public void DeleteChatMessage(int id)
        {
            if (id == 0)
            {
                throw new Exception("Parametro nao foi achado");
            }
            chatMessageRepository.Remove(new { id });
        }

        */
    }
}
