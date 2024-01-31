import TopicCode from "../components/UI/TopicCode/TopicCode";
import TopicHeader from "../components/UI/TopicHeader";
import TopicText from "../components/UI/TopicText";

export const topicTypeMap = {
    header: TopicHeader,
    text: TopicText,
    code: TopicCode
}

type TopicElementType = 'header' | 'text' | 'code';

interface TopicElementInfo {
    id: number;
    type: TopicElementType;
    innerText: string;
}

export default TopicElementInfo;