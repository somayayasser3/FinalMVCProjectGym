using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GymManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class Seeding_Data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Coach",
                columns: new[] { "ID", "Certification", "Email", "Experience", "FullName", "Gender", "HireDate", "Image", "PhoneNumber", "Salary", "Specialization" },
                values: new object[,]
                {
                    { 1, "ACSM Certified Personal Trainer", "john.smith@gym.com", 5, "John Smith", "M", new DateOnly(2021, 6, 15), "john_smith.jpg", "555-0101", 4500.00m, "Weight Training" },
                    { 2, "RYT-500 Yoga Alliance", "sarah.johnson@gym.com", 4, "Sarah Johnson", "F", new DateOnly(2022, 3, 10), "sarah_johnson.jpg", "555-0102", 4200.00m, "Yoga & Pilates" },
                    { 3, "CrossFit Level 2 Trainer", "mike.wilson@gym.com", 6, "Mike Wilson", "M", new DateOnly(2023, 1, 20), "mike_wilson.jpg", "555-0103", 4800.00m, "CrossFit" },
                    { 4, "NASM Certified Personal Trainer", "emily.davis@gym.com", 3, "Emily Davis", "F", new DateOnly(2023, 8, 5), "emily_davis.jpg", "555-0104", 3900.00m, "Cardio & HIIT" },
                    { 5, "Precision Nutrition Level 1", "david.brown@gym.com", 7, "David Brown", "M", new DateOnly(2022, 11, 12), "david_brown.jpg", "555-0105", 4300.00m, "Nutrition & Wellness" }
                });

            migrationBuilder.InsertData(
                table: "DietPlan",
                columns: new[] { "ID", "CreatedAt", "Description", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), "Low calorie diet plan focused on healthy weight loss with balanced nutrition", "Weight Loss Plan" },
                    { 2, new DateTime(2024, 1, 20, 14, 30, 0, 0, DateTimeKind.Unspecified), "High protein diet plan designed to support muscle growth and recovery", "Muscle Building Plan" },
                    { 3, new DateTime(2024, 2, 1, 9, 15, 0, 0, DateTimeKind.Unspecified), "Balanced diet plan for maintaining current weight and overall health", "Maintenance Plan" },
                    { 4, new DateTime(2024, 2, 10, 16, 45, 0, 0, DateTimeKind.Unspecified), "Low carb, high fat ketogenic diet plan for rapid weight loss", "Keto Diet Plan" },
                    { 5, new DateTime(2024, 2, 15, 11, 20, 0, 0, DateTimeKind.Unspecified), "Plant-based diet plan rich in nutrients and suitable for vegetarians", "Vegetarian Plan" }
                });

            migrationBuilder.InsertData(
                table: "MembershipType",
                columns: new[] { "ID", "Duration", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 30, "Basic Monthly", 49.99m },
                    { 2, 30, "Premium Monthly", 79.99m },
                    { 3, 365, "Basic Annual", 499.99m },
                    { 4, 365, "Premium Annual", 799.99m },
                    { 5, 30, "Student Monthly", 34.99m },
                    { 6, 30, "Senior Monthly", 39.99m }
                });

            migrationBuilder.InsertData(
                table: "WorkOutProgram",
                columns: new[] { "ID", "CoachID", "Description", "Name" },
                values: new object[,]
                {
                    { 1, 1, "A comprehensive strength training program for beginners focusing on fundamental movements", "Beginner Strength Training" },
                    { 2, 1, "High-intensity powerlifting program for experienced lifters", "Advanced Powerlifting" },
                    { 3, 2, "Dynamic yoga sequences for flexibility and mindfulness", "Yoga Flow" },
                    { 4, 2, "Traditional hatha yoga practice for beginners and intermediate practitioners", "Hatha Yoga" },
                    { 5, 3, "Daily varying functional fitness workouts", "CrossFit WOD" },
                    { 6, 4, "High-intensity interval training for cardiovascular fitness", "HIIT Cardio" },
                    { 7, 5, "Functional movement patterns for everyday activities", "Functional Fitness" }
                });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "ID", "Capacity", "DayOfWeek", "Description", "EndDate", "Image", "Name", "ProgramID", "StartDate" },
                values: new object[,]
                {
                    { 1, 15, "Monday", "Early morning strength training session", new DateOnly(2024, 5, 31), "morning_strength.jpg", "Morning Strength", 1, new DateOnly(2024, 3, 1) },
                    { 2, 10, "Wednesday", "Advanced powerlifting class for experienced members", new DateOnly(2024, 5, 31), "powerlifting.jpg", "Evening Powerlifting", 2, new DateOnly(2024, 3, 1) },
                    { 3, 20, "Tuesday", "Peaceful morning yoga session", new DateOnly(2024, 5, 31), "sunrise_yoga.jpg", "Sunrise Yoga", 3, new DateOnly(2024, 3, 1) },
                    { 4, 25, "Thursday", "Gentle yoga class for beginners", new DateOnly(2024, 5, 31), "beginner_yoga.jpg", "Beginner Yoga", 4, new DateOnly(2024, 3, 1) },
                    { 5, 12, "Friday", "High-intensity CrossFit workout", new DateOnly(2024, 5, 31), "crossfit.jpg", "CrossFit Challenge", 5, new DateOnly(2024, 3, 1) },
                    { 6, 18, "Saturday", "High-intensity interval training bootcamp", new DateOnly(2024, 5, 31), "hiit_bootcamp.jpg", "HIIT Bootcamp", 6, new DateOnly(2024, 3, 1) },
                    { 7, 16, "Sunday", "Functional movement and mobility class", new DateOnly(2024, 5, 31), "functional.jpg", "Functional Training", 7, new DateOnly(2024, 3, 1) }
                });

            migrationBuilder.InsertData(
                table: "Trainee",
                columns: new[] { "ID", "ClassID", "CoachID", "DOB", "DietPlanID", "Email", "FullName", "Gender", "JoinDate", "MembershipTypeID", "Phone" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateOnly(1990, 5, 20), 1, "alice.cooper@email.com", "Alice Cooper", "F", new DateOnly(2024, 1, 15), 2, "555-1001" },
                    { 2, 2, 1, new DateOnly(1985, 8, 14), 2, "bob.wilson@email.com", "Bob Wilson", "M", new DateOnly(2024, 1, 20), 4, "555-1002" },
                    { 3, 3, 2, new DateOnly(1992, 11, 8), 3, "carol.martinez@email.com", "Carol Martinez", "F", new DateOnly(2024, 2, 1), 1, "555-1003" },
                    { 4, 4, 2, new DateOnly(1988, 3, 25), 4, "david.lee@email.com", "David Lee", "M", new DateOnly(2024, 2, 5), 3, "555-1004" },
                    { 5, 5, 3, new DateOnly(1995, 7, 12), 5, "emma.thompson@email.com", "Emma Thompson", "F", new DateOnly(2024, 2, 10), 5, "555-1005" },
                    { 6, 6, 4, new DateOnly(1987, 12, 3), 1, "frank.garcia@email.com", "Frank Garcia", "M", new DateOnly(2024, 2, 15), 2, "555-1006" },
                    { 7, 7, 5, new DateOnly(1993, 4, 18), 3, "grace.kim@email.com", "Grace Kim", "F", new DateOnly(2024, 2, 20), 6, "555-1007" },
                    { 8, 1, 1, new DateOnly(1991, 9, 7), 2, "henry.rodriguez@email.com", "Henry Rodriguez", "M", new DateOnly(2024, 3, 1), 1, "555-1008" },
                    { 9, 3, 2, new DateOnly(1989, 6, 22), 4, "isabel.chen@email.com", "Isabel Chen", "F", new DateOnly(2024, 3, 5), 4, "555-1009" },
                    { 10, 5, 3, new DateOnly(1986, 10, 15), 5, "jack.anderson@email.com", "Jack Anderson", "M", new DateOnly(2024, 3, 10), 3, "555-1010" }
                });

            migrationBuilder.InsertData(
                table: "InBodyTest",
                columns: new[] { "ID", "Date", "Fats", "Height", "MuscleMass", "Notes", "TraineeID", "Weight" },
                values: new object[,]
                {
                    { 1, new DateOnly(2024, 1, 20), 22.50m, 165.50m, 45.80m, "Initial assessment - good starting point", 1, 70.20m },
                    { 2, new DateOnly(2024, 1, 25), 18.20m, 180.00m, 62.30m, "Experienced lifter - focus on cutting phase", 2, 85.50m },
                    { 3, new DateOnly(2024, 2, 5), 25.10m, 160.00m, 38.40m, "Beginner - focus on building strength", 3, 58.70m },
                    { 4, new DateOnly(2024, 2, 10), 15.80m, 175.20m, 58.20m, "Athletic build - maintenance phase", 4, 78.90m },
                    { 5, new DateOnly(2024, 2, 15), 20.40m, 168.00m, 42.10m, "Young trainee - focus on form and technique", 5, 64.30m },
                    { 6, new DateOnly(2024, 3, 15), 20.10m, 165.50m, 47.20m, "Progress check - lost 1.4kg fat, gained 1.4kg muscle", 1, 68.80m },
                    { 7, new DateOnly(2024, 3, 20), 16.80m, 180.00m, 63.10m, "Cutting phase progress - lost 2.3kg, maintained muscle", 2, 83.20m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "InBodyTest",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "InBodyTest",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "InBodyTest",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "InBodyTest",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "InBodyTest",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "InBodyTest",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "InBodyTest",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Trainee",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Trainee",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Trainee",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Trainee",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Trainee",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Class",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Class",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "MembershipType",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Trainee",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trainee",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trainee",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Trainee",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Trainee",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Class",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Class",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Class",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Class",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Class",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DietPlan",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DietPlan",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DietPlan",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DietPlan",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DietPlan",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MembershipType",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MembershipType",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MembershipType",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MembershipType",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MembershipType",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WorkOutProgram",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "WorkOutProgram",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Coach",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Coach",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "WorkOutProgram",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WorkOutProgram",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WorkOutProgram",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WorkOutProgram",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WorkOutProgram",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Coach",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Coach",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Coach",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
