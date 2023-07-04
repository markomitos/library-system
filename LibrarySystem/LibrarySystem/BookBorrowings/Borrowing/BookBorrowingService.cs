﻿using System;
using System.Collections.ObjectModel;
using LibrarySystem.Inventory.Copies;
using LibrarySystem.Users.MemberRules;
using LibrarySystem.Users.Members;

namespace LibrarySystem.BookBorrowings.Borrowing
{
    public class BookBorrowingService
    {
        private readonly BookBorrowingRepository _bookBorrowingRepository;
        private readonly MemberService _memberService=new MemberService(new MemberRepository());
        private readonly MemberRuleService _memberRuleService = new MemberRuleService(new MemberRuleRepository());
        private CopiesService _copiesService = new CopiesService(new CopiesRepository());

        public BookBorrowingService(BookBorrowingRepository bookBorrowingRepository)
        {
            _bookBorrowingRepository = bookBorrowingRepository;
        }

        public void SetCopiesService(CopiesService copiesService)
        {
            _copiesService = copiesService;
        }

        public void Add(BookBorrowing bookBorrowing)
        {
            _bookBorrowingRepository.Add(bookBorrowing);
        }

        public void CreateBookBorrowing(DateTime returnDate, DateTime borrowDate, bool isBookReturned, bool isBookLost,
            int bookId, string jmbg)
        {
            _bookBorrowingRepository.CreateBookBorrowing(returnDate,borrowDate,isBookReturned,isBookLost,bookId,jmbg);
        }

        public BookBorrowing? Get(int id)
        {
            return _bookBorrowingRepository.Get(id);
        }

        public ObservableCollection<BookBorrowing> GetAll(string jmbg)
        {
            return _bookBorrowingRepository.GetAll(jmbg);
        }

        public ObservableCollection<BookBorrowing> GetAllBorrowed(string jmbg)
        {
            return _bookBorrowingRepository.GetAllBorrowed(jmbg);
        }

        public int GetMaxRentDays(string jmbg)
        {
            return _memberRuleService.GetMaxRentDays(_memberService.GetMemberType(jmbg));
        }

        public bool IsReturnLate(BookBorrowing borrowing)
        {
            return GetBorrowDate(borrowing.Id).AddDays(GetMaxRentDays(borrowing.Jmbg)) <= DateTime.Now;
        }

        public int CalculateLateFee(BookBorrowing borrowing)
        {
            if (!IsReturnLate(borrowing)) return 0;
            int feePerDay = 20;
            DateTime firstDayOfPenalty = GetBorrowDate(borrowing.Id).AddDays(GetMaxRentDays(borrowing.Jmbg));
            return (DateTime.Now - firstDayOfPenalty).Days * feePerDay;
        }

        public int CalculateFee(BookBorrowing borrowing)
        {
            return CalculateLateFee(borrowing) + _copiesService.CalculateDamagedFee(borrowing.CopyId);
        }

        public void ReturnBook(BookBorrowing borrowing)
        {
            _bookBorrowingRepository.Finish(borrowing.Id);
            _copiesService.ReturnCopy(borrowing.CopyId);
        }

        public DateTime GetBorrowDate(int id)
        {
            return _bookBorrowingRepository.GetBorrowDate(id);
        }
    }
}
