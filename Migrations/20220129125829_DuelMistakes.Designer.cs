// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using twitter_contest_dotnet.Data;

#nullable disable

namespace twitter_contest_dotnet.Migrations
{
    [DbContext(typeof(twitter_contest_dotnetContext))]
    [Migration("20220129125829_DuelMistakes")]
    partial class DuelMistakes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("twitter_contest_dotnet.Models.Contest", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.ToTable("Contest");
                });

            modelBuilder.Entity("twitter_contest_dotnet.Models.Duel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ContestId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProposalTweeterAId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProposalTweeterBId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ResponseTweeterId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TweeterALikes")
                        .HasColumnType("int");

                    b.Property<int>("TweeterBLikes")
                        .HasColumnType("int");

                    b.Property<string>("UserProposalTweeterId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ContestId");

                    b.HasIndex("ProposalTweeterAId");

                    b.HasIndex("ProposalTweeterBId");

                    b.HasIndex("ResponseTweeterId");

                    b.HasIndex("UserProposalTweeterId");

                    b.ToTable("Duel");
                });

            modelBuilder.Entity("twitter_contest_dotnet.Models.Tweeter", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TwitterUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tweeter");
                });

            modelBuilder.Entity("twitter_contest_dotnet.Models.Duel", b =>
                {
                    b.HasOne("twitter_contest_dotnet.Models.Contest", "Contest")
                        .WithMany("Duels")
                        .HasForeignKey("ContestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("twitter_contest_dotnet.Models.Tweeter", "ProposalTweeterA")
                        .WithMany()
                        .HasForeignKey("ProposalTweeterAId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("twitter_contest_dotnet.Models.Tweeter", "ProposalTweeterB")
                        .WithMany()
                        .HasForeignKey("ProposalTweeterBId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("twitter_contest_dotnet.Models.Tweeter", "ResponseTweeter")
                        .WithMany()
                        .HasForeignKey("ResponseTweeterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("twitter_contest_dotnet.Models.Tweeter", "UserProposalTweeter")
                        .WithMany()
                        .HasForeignKey("UserProposalTweeterId");

                    b.Navigation("Contest");

                    b.Navigation("ProposalTweeterA");

                    b.Navigation("ProposalTweeterB");

                    b.Navigation("ResponseTweeter");

                    b.Navigation("UserProposalTweeter");
                });

            modelBuilder.Entity("twitter_contest_dotnet.Models.Contest", b =>
                {
                    b.Navigation("Duels");
                });
#pragma warning restore 612, 618
        }
    }
}
