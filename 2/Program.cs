using System;
using System.Collections.Generic;
using System.Linq;

var part2 = true;

var position = File.ReadAllLines("input.txt")
    .Select(line => line.Split(" "))
    .Select(tokens => (direction: tokens[0], length: Convert.ToInt32(tokens[1])))
    .Select(vector => (
        vector.direction switch {
            "forward" => (horizontal: vector.length, depth: 0, aim: 0),
            "up" => (horizontal: 0, depth: part2 ? 0 : -vector.length, aim: -vector.length),
            "down" => (horizontal: 0, depth: part2 ? 0 : vector.length, aim: vector.length),
        }
    ))
    .Aggregate(
        (horizontal: 0, depth: 0, aim: 0),
        (current, next) => (
            horizontal: current.horizontal + next.horizontal,
            depth: current.depth + (
                (part2 && next.horizontal != 0)
                    ? next.horizontal * current.aim
                    : next.depth),
            aim: current.aim + next.aim));

Console.WriteLine(position.horizontal * position.depth);
