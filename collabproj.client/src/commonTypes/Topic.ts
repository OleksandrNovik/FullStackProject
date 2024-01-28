interface Topic {
    id: number;
    name: string;
    subTopics?: Topic[];
}

export default Topic;