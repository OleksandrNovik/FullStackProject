import TopicHeader from "../components/UI/TopicHeader";

export const topicTypeMap = {
    header: TopicHeader,
    text: TopicHeader,
    code: TopicHeader
}

type TopicElementType = 'header' | 'text' | 'code';

interface TopicElementInfo {
    id: number;
    type: TopicElementType;
    innerText: string;
}

export default TopicElementInfo;